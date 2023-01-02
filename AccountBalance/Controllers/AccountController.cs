using AccountBalance.Authentication;
using AccountBalance.Context;
using AccountBalance.Models;
using AccountBalance.Repositories;
using AccountBalance.Repositories.Interfaces;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace AccountBalance.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountRepository _repo;
        public AccountController(IAccountRepository repo)
        {
            _repo = repo;
        }

        [BasicAuthentication]
        [MyAuthorize(Roles = "Admin,User")]
        [Route("api/GetAllAccounts")]
        public HttpResponseMessage GetAllAccounts()
        {
            try
            {
                var accounts = _repo.GetAll();
                List<AccountDTO> accountDTOs = Mapper.Map<List<AccountModel>, List<AccountDTO>>(accounts);
                accountDTOs.ForEach(x =>
                {
                    x.AccountBalance.Replace("\"", "\\\"");
                });
                return Request.CreateResponse(HttpStatusCode.OK, accountDTOs);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        //[BasicAuthentication]
        [HttpPost]
        //[MyAuthorize(Roles = "Admin")]
        [Route("api/UploadAccount")]
        public HttpResponseMessage UploadAccount()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var file = httpRequest.Files[0];
                    var stream = file.InputStream;
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true,
                    };
                    using (var reader = new StreamReader(stream))
                    using (var csvReader = new CsvReader(reader, config))
                    {
                        try
                        {
                            if (file.FileName.Contains(".txt"))
                            {
                                csvReader.Configuration.Delimiter = "\t";
                                csvReader.Configuration.IgnoreQuotes = true;
                            }
                            csvReader.Read();
                            csvReader.ReadHeader();
                            var header = csvReader.Context.HeaderRecord;
                            String[] seperator = { "for " };
                            var titles = header[0].Split(seperator, 2, StringSplitOptions.RemoveEmptyEntries);
                            string month = titles[1];
                            int year = DateTime.Now.Year;
                            // Store all content inside a new List as objetcs
                            var records = csvReader.GetRecords<AccountExcelDTO>().ToList();
                            List<AccountModel> accounts = Mapper.Map<List<AccountExcelDTO>, List<AccountModel>>(records);
                            var createdDate = DateTime.Now;
                            accounts.ForEach(x =>
                            {
                                x.Month = month;
                                x.Year = year;
                                x.CreatedDate = createdDate;
                            });
                            _repo.BulkInsertOrUpdate(accounts, month, year);
                        }
                        catch (CsvHelper.HeaderValidationException exception)
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.ToString());
                        }
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "No file is passed.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, "File has been uploaded.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
            
        }
    }
}

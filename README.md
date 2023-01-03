# AccountBalanceDashboard

This is an account balance dashboard built with Angular as front end, and ASP.NET Web API as BackEnd.
Admin is able to upload account balance in csv or txt monthly and see the account dashboard, while user is only able to view dashboard.

Package version used in this project:<br>
Angular CLI: 8.0.0 <br>
Node: 18.12.1 <br>

@angular-devkit/architect    0.800.0<br>
@angular-devkit/core         8.0.0<br>
@angular-devkit/schematics   8.0.0<br>
@schematics/angular          8.0.0<br>
@schematics/update           0.800.0<br>
rxjs                         6.4.0<br>

Command to install:<br>
npm install -g @angular/cli@^8.0.0<br>
npm install --save @angular/material

Two accounts to login:<br>
1) Admin: <br>
Username: allen<br>
Password: 123
2) User<br>
Username: user<br>
Password: 123

Login to this url:<br>
https://accountbalance.azurewebsites.net/login<br>

Login As Admin:<br>
1)You will see three buttons on the dashboard. Upload is where admin can upload csv or txt file of account balance, ViewAccount is where admin can see the account balance dashboard, and SignOut button logs off admin account.<br>
![image](https://user-images.githubusercontent.com/72980013/210330340-5e655748-5b7e-4ec5-8291-aba5be4eb766.png)<br>
2)Click on the Upload button, where admin can choose a file and click on Upload File to update account balance in dashboard. After the file is successfully uploaded. Go Back to Dashboard and click on View Account to check on Account Balance.<br><br>
<b>Upload Page</b><br>
![image](https://user-images.githubusercontent.com/72980013/210331361-086f6d23-9fa9-45d0-93f8-426cade1bc35.png)<br><br>
<b>View Account Page</b><br>
![image](https://user-images.githubusercontent.com/72980013/210331483-0bfb9c95-f645-4007-845a-8824e35f4940.png)


Login As User:<br>
1)User should able to view dashboard only.<br>
![image](https://user-images.githubusercontent.com/72980013/210331873-3d7d589b-5cbe-4851-827d-426b81e0b5b5.png)<br>
![image](https://user-images.githubusercontent.com/72980013/210331911-77bb8cb1-08c1-41c6-8702-e1bb77404fc0.png)


insert into EmailTemplates values('TASK_REMINDER_SUBJECT','Task Reminder - #Task# due #DueDate#',GETDATE(),GETDATE(),1,1)

insert into EmailTemplates values('TASK_REMINDER','<!DOCTYPE html>
<html>
<head>
  <title>Task Reminder</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background-color: #f2f2f2;
      margin: 0;
      padding: 0;
    }
    
    .container {
      max-width: 600px;
      margin: 20px auto;
      background-color: #fff;
      border-radius: 5px;
      box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
      padding: 20px;
    }
    
    h1 {
      color: #333;
    }
    
    p {
      color: #777;
    }
    
    .button {
      display: inline-block;
      background-color: #4CAF50;
      color: #fff;
      text-decoration: none;
      padding: 10px 20px;
      border-radius: 4px;
      transition: background-color 0.3s;
    }
    
    .button:hover {
      background-color: #45a049;
    }
  </style>
</head>
<body>
  <div class="container">
    <h1>Task Reminder</h1>
    <p>Dear #User#,</p>
    <p>This is a friendly reminder for the Task: #Task# you need to complete:</p>
   </br>
    <p>Please make sure to complete the task by #DueDate#.</p>
    <p>Thank you!</p>
   
  </div>
</body>
</html>
',GETDATE(),GETDATE(),1,1)
insert into EmailTemplates values('TASK_STATUS_UPDATE_SUBJECT','Task Status Update - #Task#',GETDATE(),GETDATE(),1,1);
insert into EmailTemplates values('TASK_STATUS_UPDATE','<!DOCTYPE html>
<html>
<head>
  <title>Task Status Update</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background-color: #f6f6f6;
      padding: 20px;
    }
    .container {
      max-width: 600px;
      margin: 0 auto;
      background-color: #fff;
      padding: 30px;
      border-radius: 5px;
    }
    h1 {
      color: #333;
      font-size: 24px;
      margin-bottom: 20px;
    }
    p {
      color: #555;
      font-size: 16px;
      line-height: 1.5;
      margin-bottom: 20px;
    }
    .button {
      display: inline-block;
      background-color: #4CAF50;
      color: #fff;
      padding: 10px 20px;
      text-decoration: none;
      border-radius: 5px;
    }
    .button:hover {
      background-color: #45a049;
    }
  </style>
</head>
<body>
  <div class="container">
    <h1>Task Status Update</h1>
    <p>Dear #user#,</p>
    <p>The status of the following task has been updated:</p>
    <p><strong>Task Name:</strong> #task#</p>
    <p><strong>Status:</strong> #status#</p>
    <p>Please review the updated status and take any necessary actions.</p>
    <p>Thank you!</p>

  </div>
</body>
</html>
',GETDATE(),GETDATE(),1,1);
insert into EmailTemplates values('TASK_UPDATE_SUBJECT','Task Update - #Task#',GETDATE(),GETDATE(),1,1);
insert into EmailTemplates values('TASK_UPDATE','<!DOCTYPE html>
<html>
<head>
  <title>Task Update</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background-color: #f6f6f6;
      padding: 20px;
    }
    .container {
      max-width: 600px;
      margin: 0 auto;
      background-color: #fff;
      padding: 30px;
      border-radius: 5px;
    }
    h1 {
      color: #333;
      font-size: 24px;
      margin-bottom: 20px;
    }
    table {
      width: 100%;
    }
    table th {
      background-color: #f0f0f0;
      padding: 10px;
      text-align: left;
    }
    table td {
      padding: 10px;
    }
    .button {
      display: inline-block;
      background-color: #4CAF50;
      color: #fff;
      padding: 10px 20px;
      text-decoration: none;
      border-radius: 5px;
    }
    .button:hover {
      background-color: #45a049;
    }
  </style>
</head>
<body>
  <div class="container">
    <h1>Task Update</h1>
    <table>
      <tr>
        <th>Task Id</th>
        <th>Task Name</th>
        <th>Description</th>
        <th>Assigned By</th>
        <th>Priority</th>
        <th>Due Date</th>
      </tr>
      <tr>
        <td>#DemoId#</td>
        <td>#demo#</td>
        <td>#demoDescription#</td>
        <td>#demoAssigned#</td>
        <td>#demoPriority#</td>
        <td>#demoDueDate#</td>
      </tr>
    </table>
    <p>Dear Team,</p>
    <p>The following updates have been made to the task:</p>
    <p>Please review the changes and take any necessary actions.</p>
    <p>Thank you!</p>
     </div>
</body>
</html>
',GETDATE(),GETDATE(),1,1);
insert into EmailTemplates values('TASK_ASSIGNED_SUBJECT',' Task Assigned - #TASK_NAME#',GETDATE(),GETDATE(),1,1);
insert into EmailTemplates values('TASK_ASSIGNED','<!DOCTYPE html>
<html>
<head>
  <title>Task Assigned</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background-color: #f6f6f6;
      padding: 20px;
    }
    .container {
      max-width: 600px;
      margin: 0 auto;
      background-color: #fff;
      padding: 30px;
      border-radius: 5px;
    }
    h1 {
      color: #333;
      font-size: 24px;
      margin-bottom: 20px;
    }
    table {
      width: 100%;
    }
    table th {
      background-color: #f0f0f0;
      padding: 10px;
      text-align: left;
    }
    table td {
      padding: 10px;
    }
    
  </style>
</head>
<body>
  <div class="container">
    <h1>Task Assigned</h1>
    <table>
      <tr>
        <th>Task Id</th>
        <th>Task Name</th>
        <th>Description</th>
        <th>Assigned By</th>
        <th>Due Date</th>
        <th>Priority</th>
      </tr>
      <tr>
        <td>#DemoId#</td>
        <td>#demo#</td>
        <td>#demoDescription#</td>
        <td>#demoAssigned#</td>
        <td>#demoDueDate#</td>
        <td>#demoPriority#</td>
      </tr>
    </table>
    <p>Dear #USER#,</p>
    <p>A new task has been assigned to you. Please review the details below:</p>
    <p>Please complete the task before the due date #DueDate#.</p>
    <p>Thank you!</p>
    <p>Best regards,</p>
    <p>Your Company</p>
  </div>
</body>
</html>
',GETDATE(),GETDATE(),1,1);

update AppSettings 
set [Value] = 'cmvzcoaavlxinfyd' where Id = 2;

insert into AppSettings values('SMPT_USERNAME','siddiqshaikh170@gmail.com',GETDATE(),1,GETDATE(),1);
insert into AppSettings values('SMPT_PASSWORD','Siddiq@1234',GETDATE(),1,GETDATE(),1);
insert into AppSettings values('SMPT_SERVER_PORT','587',GETDATE(),1,GETDATE(),1);
insert into AppSettings values('SMPT_SERVER_HOST','smtp.gmail.com',GETDATE(),1,GETDATE(),1);

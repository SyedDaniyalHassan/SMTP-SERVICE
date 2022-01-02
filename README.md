# **SMTP Windows Service**

You have multiple applications that need to send emails to recipients. You are required to create a
centralized application which can send emails using SMTP. Create a windows service which reads a JSON
file (1 json per file) after every 15 minutes from a fixed location (provided in the app.config) and sends
email to the receipts. Following is the JSON input sample:


{
"To": “”,


"Subject": “”,


"MessageBody": “”


}

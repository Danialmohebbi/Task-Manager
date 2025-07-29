# Student Task Manager

A Windows Forms (WinForms) application built using C# that enables students to efficiently manage and track their academic or personal tasks. it includes authentication, personalized task management, filtering with LINQ, and integration with PostgreSQL hosted on AWS.

---

## Features

### 🔐 Authentication & Registration
- Students can **register** with a **username**, **email**, and **password**.
- Login using either **username or email**.
- **Forgot password**: OTP (One-Time Password) is sent via email for secure verification and reset.

### 📋 Task Management
Students can:
1. **View Tasks**
2. **Add New Tasks**
3. **Edit Existing Tasks**
4. **Mark Tasks as Done**
5. **Delete Tasks**
6. **Logout**

Each task includes:
- Title  
- Description  
- Due Date  
- Completed (Yes/No)  
- Priority (Low / Medium / High)  
- Tag  
- Recurrence (Daily / Weekly / Monthly / Yearly)  
- Created At  
- Updated At  
- Completed At  

### 🔍 Filtering and Search
- Filter tasks by:
  - **Priority**
  - **Completion status**
  - **Recurrence**
  - **Due date**
  - **Keyword**
  - **Tag**
- Implemented using **LINQ** for clean and efficient querying.

---

## 🛠 Tech Stack

| Component        | Technology                     |
|------------------|--------------------------------|
| Language         | C#                             |
| Framework        | .NET Windows Forms (WinForms)  |
| Database         | PostgreSQL                     |
| Hosting          | Amazon Web Services (AWS RDS)  |
| Email Service    | SMTP-based email OTP sender    |

---

## Database Design

- **Students Table**
  - `Id`, `FirstName`, `LastName`, `Username`, `Email`, `Password`

- **Tasks Table**
  - Linked to `StudentId`
  - Includes all task attributes listed above

---

##  How to Run

1. **Clone this repository**
   ```bash
   git clone https://github.com/your-username/student-task-manager.git
2. **Add Config**

Create a `Config` folder inside the `Task_Manager` directory. Then add two files inside it: `databaseinfo.json` and `smpt.json`.

### ➤ `Task_Manager/Config/databaseinfo.json`
```json
{
  "Host": "URL",
  "Port": 5432,
  "Username": "your_username",
  "Password": "your_password",
  "Database": "database_name",
  "SSL": "Require",
  "ServerCertification": true
}
```

### ➤ `Task_Manager/Config/smpt.json`
```json
{
  "fromEmail": "your_email",
  "Password": "your_password",
  "SmptHost": "your_mail_smpt_host",
  "SmptPort": 587
}

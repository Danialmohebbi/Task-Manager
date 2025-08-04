# 🎓 Student Task Manager

A Windows Forms (WinForms) application built with C# for students to manage any tasks. Includes authentication, task filtering, PostgreSQL integration via AWS, and email-based password recovery.
---
# Tables Of Contents
- [Features](#features)
- [User Documentation](#user-documentation)
- [Developer Documentation](#developer-documentation)

---

## ✅ Features

### 🔐 Authentication
- Student **registration** using username, email, and password
- **Login** with either username or email
- **Forgot password** via email OTP verification

### 🗂 Task Management
Students can:
- **View** tasks
- **Add** new tasks
- **Edit** existing tasks
- **Delete** tasks
- **Mark** tasks as completed
- **Logout**

### 🧾 Task Attributes
Each task includes:
- `Title`
- `Description`
- `Due Date`
- `Completed` (Yes/No)
- `Priority` (Low / Medium / High)
- `Category` (Tag)
- `Recurrence` (Daily / Weekly / Monthly / Yearly)
- `Created At`
- `Updated At`
- `Completed At`

### 🔍 Filtering & Search (via LINQ)
Filter or search tasks by:
- **Priority**
- **Completion status**
- **Recurrence**
- **Due date**
- **Keyword**
- **Category**

---

## 👥 User Documentation

### 🛠️ How to Run the App

1. **Clone the Project**
   ```bash
   git clone https://github.com/your-username/student-task-manager.git
   ```

2. **Set Up Configuration Files**

   Inside the `Task_Manager/Config` folder, create two files:

   #### ➤ `databaseinfo.json`
   ```json
   {
     "Host": "your-db-host",
     "Port": 5432,
     "Username": "your_username",
     "Password": "your_password",
     "Database": "your_database",
     "SSL": "Require",
     "ServerCertification": true
   }
   ```

   #### ➤ `smpt.json`
   ```json
   {
     "fromEmail": "your_email",
     "Password": "your_email_password",
     "SmptHost": "smtp.yourmail.com",
     "SmptPort": 587
   }
   ```

3. **Open in Visual Studio**
   - Build and Run the application (F5)

---

### 🧑‍🏫 How to Use the App

#### 1. Register or Log In
- Register using your **name**, **email**, and **password**
- Login with either **email** or **username**

#### 2. Forgot Password?
- Click "Forgot Password"
- Enter your email
- An OTP will be sent to reset your password

#### 3. Task Management
- Click on the last row and fill in **Obligatory fields** to add a task.
- click on a field of a task to **Edit**
- Use **checkbox** or button to mark a task as **Completed**
- Click **Delete** to remove a task given it's task_id

#### 4. Filtering Tasks
Use the built-in filters or search bar to find tasks by:
- Priority
- Tag 
- Overdue
- Recurrence type 
- Keyword in title or description

#### 5. Logging Out
- Click the **Logout** button to end your session

---

## 👨‍💻 Developer Documentation

### Tech Stack

| Component        | Technology                     |
|------------------|--------------------------------|
| Language         | C#                             |
| Framework        | .NET Windows Forms (WinForms)  |
| Database         | PostgreSQL                     |
| Hosting          | AWS RDS                        |
| Email Service    | SMTP                           |

---

### 🗄️ Database Schema

#### 👤 Students Table


| Field        | Type         | Description                            |
|--------------|--------------|----------------------------------------|
| student_id   | SERIAL       | Primary key                            |
| first_name   | VARCHAR(50)  | Required                               |
| last_name    | VARCHAR(50)  | Optional                               |
| email        | VARCHAR(100) | Must be unique and valid format        |
| username     | VARCHAR(100) | Must be unique                         |
| password_hash| VARCHAR(255) | Hashed password                        |

---

#### 📋 Tasks Table


| Field         | Type         | Description                                  |
|---------------|--------------|----------------------------------------------|
| task_id       | SERIAL        | Primary key                                 |
| student_id    | INT           | Foreign key to `students.student_id`        |
| title         | VARCHAR(100)  | Task title (required)                       |
| description   | TEXT          | Optional task description                   |
| due_date      | TIMESTAMP     | Task deadline                               |
| completed     | BOOLEAN       | Default false                               |
| priority      | INT           | 0 (Low), 1 (Medium), 2 (High)               |
| category      | VARCHAR(100)  | Task tag/category                           |
| recurrence    | INT           | 1=Daily, 7=Weekly, 30=monthly,365=yearly.   |
| created_at    | TIMESTAMP     | Auto-generated when created                 |
| updated_at    | TIMESTAMP     | Auto-updated when edited                    |
| completed_at  | TIMESTAMP     | Set when task is marked as completed        |

---


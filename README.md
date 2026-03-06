# 🏥 Medix-HealthCare

**Medix-HealthCare** is a full-stack healthcare claim processing system built using **ASP.NET Core Web API** and **React.js**.
The application simulates a real-world **pharmacy claim adjudication workflow** 

It allows pharmacies to submit claims, claim officers to review them, and finance teams to process payments.

---

# 🚀 Features

### 🔐 Authentication & Authorization

* JWT based authentication
* Role-based access control
* Secure password hashing

### 👨‍💼 Admin Module

* Create and manage users
* Create healthcare policies
* View all claims in the system

### 💊 Pharmacy Module

* Submit pharmacy claims
* NCPDP-style claim data submission
* Track submitted claims

### 👨‍⚕️ Claim Officer Module

* Review pending claims
* Approve or reject claims
* Apply adjudication rules

### 💰 Finance Module

* View approved claims
* Process payments
* Generate transaction records

---

# 🏗️ System Architecture

```
React Frontend
      │
      │ API Calls
      ▼
ASP.NET Core Web API
      │
      │ Entity Framework
      ▼
SQL Server Database
```

---

# 🔄 Claim Processing Workflow

```
Admin creates Policy
        │
        ▼
Pharmacy submits claim
        │
        ▼
Claim status → Pending
        │
        ▼
Claim Officer reviews claim
        │
 ┌──────┴──────┐
 ▼             ▼
Approved      Rejected
  │
  ▼
Finance processes payment
  │
  ▼
Claim status → Paid
```

---

# 🛠️ Tech Stack

## Backend

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* AutoMapper

## Frontend

* React.js
* Axios
* React Router


# 🧪 Example Claim Submission

```
BIN:112345,
CARDHOLDERID:3,
NDC:NDC0002,
QUANTITY:30,
AMOUNT:1500,
POLICY:POL1001
```

### 1️⃣ Clone Repository

```
git clone https://github.com/Siddharth2-sidd/Medix-HealthCare.git
```

## 📌 Future Improvements

* Email notifications
* Payment gateway integration
* Claim analytics dashboard
* Role-based UI dashboards
* Docker deployment

---

## 👨‍💻 Author

**Siddharth Singh Tiwari**

GitHub:
https://github.com/Siddharth2-sidd

---

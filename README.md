# QTip Coding Challenge  
_A lightweight, fun test of data detection, tokenization, classification, and full-stack ability._

---

## 🧩 Overview

People paste sensitive information into tools constantly without realising it.  
Your job is to build a tiny prototype — **QTip** — that behaves like a *“data spellchecker”* for sensitive data.

This challenge is intentionally small.  
We want to see **how you think**, **how you structure code**, and **how you solve problems end-to-end**, not how many hours you can grind.

You are free to choose your own architecture, folder structure, and implementation patterns.

---

## 🎯 Core Requirements

### 1. Frontend Behaviour

Build a simple page that includes:

#### **A multiline text box**
Users can freely type or paste text into it.

As soon as an **email address** appears:

- It must be visually underlined (a squiggly/wavy underline)
- On hover, a tooltip should appear saying something like:  
  **"PII – Email Address"**

You are free to implement this however you like  
(e.g. contenteditable, overlaying spans, etc.).

#### **A Submit button**
When clicked, the full content of the text box is sent to the backend.

#### **A statistics panel (right side)**
A simple box displaying:

```
Total PII emails submitted: X
```

Where `X` must come from the backend and reflect:

- All previously submitted emails  
- Persisted across page reloads

The panel must update after each submission.

---

### 2. Backend Behaviour

When the frontend sends the submitted text:

1. The backend must detect **all email addresses** inside it.
2. Each detected email must be given a classification tag  
   (we will provide the tag name, e.g. `"PII.Email"`).
3. The backend must **tokenize** the submitted text by replacing each detected email address with a **random token**.
   - Each email → its own unique token  
   - Token format is up to you (e.g. `{{TKN-abc123}}`, `__emailToken1__`, etc.)
4. The backend must persist:
   - The **tokenized text submission**
   - Each **detected email** as its own stored classification record
     - including the token
     - and the original email value
     - and the classification tag

5. The backend must expose a way for the frontend to retrieve:
   - The total number of PII email items submitted so far

> You are free to structure the backend however you like.  
> Minimal APIs, controllers, services, DDD-lite — up to you.

---

### 3. Database Requirements

You may use any relational database (SQLite, Postgres, SQL Server, etc.).

Your database must persist:

- Tokenized text submissions
- Classified email items  
  (one row per detected email)

Schema design is entirely up to you, but keep it sensible and readable.

---

## ⭐ Optional Part 2: Dynamic Classification Tags

If you have spare time (totally optional), you can implement:

> **User- or developer-defined classification types**, each with a  
> - tag name  
> - regex pattern  

For example:

| Tag Name         | Regex Pattern      |
|------------------|--------------------|
| `Finance.IBAN`   | IBAN regex         |
| `PII.Phone`      | phone regex        |
| `Security.Token` | API key regex      |

When part 2 is implemented:

- On submission:
  - The backend should run all defined tag patterns against the text
  - Tokenize each detected match
  - Persist the classifications just like emails

You do *not* need to add UI for creating rules (unless you want to).  
Hard-coded, JSON-backed, or DB-seeded rules are all acceptable.

Please note in the README how you implemented this if you choose to do it.

---

## 🧪 What We’re Looking For

We evaluate:

### ✔️ Clarity of thinking  
### ✔️ Clean, maintainable backend code  
### ✔️ Correct tokenization logic  
### ✔️ Accurate detection and classification  
### ✔️ A functional UI with real-time highlighting  
### ✔️ A working end-to-end flow  
### ✔️ Sensible trade-offs  
### ✔️ A working Docker Compose setup

We **do not** expect:

- Perfect styling  
- Production-grade complexity  
- Tests (unless you want to include them)  
- Enterprise patterns or overengineering  

This should be a **small** project built in **a few focused hours**, not a weekend killer.

---

## 🐳 Final Deliverable: Docker Compose

Your final submission must include a **Docker Compose** setup that runs:

- The backend  
- The database  
- The frontend  

Running:

```bash
docker compose up
```

should start the entire application end-to-end.

---

## 📦 Submission Checklist

Please submit:

- Source code (frontend + backend)
- Docker Compose file
- A README explaining:
  - How to run the application
  - Any assumptions or shortcuts you took
  - (Optional) Notes on Part 2 if implemented

---

Good luck — and have fun with it!  
We care far more about **how you think** than how many features you add.

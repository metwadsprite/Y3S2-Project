# 1. Introduction
## 1.1 Purpose
The system requirements specification document describes what the Automatic Management of the Students in a Faculty is to do, and how the system will perform each function. 

The audiences for this document include the teachers, the students and the secretaries.
## 1.2 Scope
The application's name will be GASF, from the romanian for Automatic Management of the Students in a Faculty (Gestionarea Automata a Studentilor Facultatii).
This will allow the following actions:
- collect data of the eductaional planifications, study types and their students;
- data management;
- informations supply through a web portal;
- reports generation;
- system interogation;
- management of the documents in the faculty's secretariat.

![GASF system](wwwroot/images/gasf.png)

The main benefit of this application is making students management an easier and safer work, reducing probability of human errors. 
This will be an improvement both for faculty employees and for students.
## 1.3 Definitions, acronyms, and abbreviations
| Name          | Description   |
| ------------- |:-------------:|
|AMSF           | Automatic Management of the Students in a Faculty |
| SRS           | System Requirements Specification                 |
## 1.4 References
| Title         | Link          |
| ------------- |:-------------:|
|IEEE 830       |http://www.math.uaa.alaska.edu/~afkjm/cs401/IEEE830.pdf |
|               |               |
## 1.5 Overview
This document follows the IEEE standard. It has three parts:

##### 1. Introduction 
Information about the scope of the SRS and of the project.

##### 2. Overall Description 
Description of the system.

##### 3. Specific requirements 
Requirements of the software system.

# 2. Overall Description
## 2.1 Product perspective
The app will provide similar functionalities to student records provided by universities. Everything is handeled within the system with no outside dependencies.

### 2.1.1 User interfaces
There are multiple types of users that will use the app the likes of which are: students, teachers and university staff, with all of them using the app in different ways.

### 2.1.2 Hardware interfaces
The app is hosted on a server and can be accessed by the users on any device, be it computer or smartphone.

### 2.1.3 Software interfaces
The app will require a SQLServer database to store all present entities.

### 2.1.4 Communication interfaces
The app is hosted on a server and this it can be accessed remotely from any network.

### 2.1.5 Memory constraints
On the user's side there are no requirements for using the app. The server on which it is hosted will require enough storage depending on the number of records.

### 2.1.6 Operations
Only the teachers and university staff can modify entities, while students can only view them.

### 2.1.7 Site adaptation requirements
The app should be usuable on any type of device and not be constrained by screen size or aspect ratio. The app ought to be able to be used by multiple users at the same time without interruptions.

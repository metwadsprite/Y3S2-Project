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

## 2.2	Product functions

1) The user interface is accessible through a web site with differentiated and secured access for different user roles.
2)  The data from the web site are easy to view and to locate 
3) The system contains the following modules: 
      *	the module for data collection; 
      *	the reporting module;
      *	the operations logging module.
4) Reports are viewable in various forms, the user can save them in different formats such as CVS, XML, XLS and PDF.
5)  Data management must be ensured by data extraction functionalities from different data sources (databases, Excel files, text file), by performing filters and other transformations on the data needed to integrate them into the database.

#### Functionalities of the web site:

1)	 A user of the system must be able to register through the web interface.
2)	 Having initially a predefined set of rights, allowing differentiated access to data.
3)	 The data collected by the user will be collected through the web interface.
4)	 The user will be able to make changes, create and generate reports accordingly with the rights allocated.
5)	 The documents can be searched:
       * according to the type of file searched;
       * after the date of creation;
       * after the author of the document; 
       * after the content of the document.
6)	The data will be displayed on the web page as a table
7)	The data can be saved in a format standard: CSV, XML or XLS.
8)	The system will allow the definition of user groups and the execution of operations at group level (for example: sending emails to all group members).
9)	Data validation will be performed in the module that implements the user interface and will generate error messages, and frequent error cases will suggest ways to resolve them.


#### Data base requirements:
1.	the database should allow the management of a large amount of data on the school situation of a student.
2.	the database management system must allow:
3.	immediate data recovery in a specified moment of time,
4.	offline backup support,
5.	web browser administration, 
6.	simultaneous access pf users to the information, 
7.	users and groups of users with different types of access, 
8.	monitoring all types of queries,
9.	implementing complex data structures.
10.	stocks can be seen in “log” transactions for all activities in the sistem. For each activity it can be identified the user that has realized the action and all the relevant data of the accessed / modified information.

## 2.3	User characteristics

The users of this web site should be students, teachers or official representatives of a university or teaching academy.

There is no need of special skills to use this web site. 

# 3. Specific Requirements
## 3.1 External interface requirments
### 3.1.1 User Interfaces
The user interface will be simple and consistent, using terminology commonly understood by the intended users of the system. The system will have a simple interface, consistent with industry standard interfaces.

The user should see the login page, every time he/she tries to connect on the platform. There can be three types of users: student, teacher, secretary.
![GASF system](wwwroot/images/login.png)

Every user have a profile page with some important informations about him/ her.
![GASF system](wwwroot/images/profile.png)

Stdents will have a page with their school situation.
![GASF system](wwwroot/images/situation.png)

Teachers will have a page with their subjects, and for each of it the groups that have that subject. When the teacher press select, another interface will be opened.
![GASF system](wwwroot/images/subjects.png)

The interface that appears after the teacher press the select button, will be similar with the one in the below picture. Here the teacher introduces students grades.
![GASF system](wwwroot/images/group.png)

The secretary can add/ edit students, view students and teachers and generate reports about them.
![GASF system](wwwroot/images/secretary.png)
### 3.1.2 Hardware Interfaces
The system requires an architecture x86 in order to work properly.
### 3.1.3 Software Interfaces
The system will use: 
* ASP.NET Core MVC;
* HTML;
* CSS;
* Microsoft SQL Server. 
### 3.1.4 Communication Interfaces
The system will use HTTP and HTTPS protocols for communication with the web browser.

## 3.3 Performance Requirements
The requirements in this section provide a detailed specification of the user interaction with the softwareand measurements placed on the system performance.

### 3.3.1 Prominent search feature
 
ID: QR1
 
TITLE: Prominent search feature
 
DESCRIPTION: The search feature should be prominent and easy to find for the user.

### 3.3.2 Usage of the search feature
 
ID: QR2

DESCRIPTION: The different search options should be evident, simple and easy to understand (secretary can search students, subjects, teachers etc; students can search teacher, subjects, exams etc; teachers can search students).

### 3.3.3 Usage of the result in the list view 
 
ID: QR3
 
DESCRIPTION: The results displayed in the list view should be user friendly and easy to understand. Selecting anelement in the result list should only take one click.

### 3.3.4 Response time

ID: QR4

DESCRIPTION: The data system shall show no visible deterioration in response time as the number of persons increases. Response times seen by users should be on the order of a few seconds or less.

## 3.4 Design constraints

### 3.4.1 SQL usage

ID: QR5

DESCRIPTION: It is required the usage of Microsoft SQL Server.

### 3.4.2 Number of users

ID: QR6

DESCRIPTION: The  server  shall  be  capable  of  supporting  no  less than 100 concurrent connections.

## 3.5 Software system attributes
The requirements in this section specify the required reliability, availability, scalability and integrability of the software system.

### 3.5.1 Reliability

ID: QR7

DESCRIPTION: The software system should produce a low error rate and should have ability to continue to operate under predefined conditions.

### 3.5.2 Availability

ID: QR8

DESCRIPTION: This is expressed as the ratio of the available system time to the total working time.

### 3.5.3 Scalability

ID: QR9

DESCRIPTION: The system should handle load increases without decreasing performance, or the possibility to rapidly increase the load.


### 3.5.4 Integrability

ID: QR11

DESCRIPTION: Integrability is responsible for system operation and the transmission of data and its exchange with other external systems. The system should be
well-designed, in a way that it facilitates integration with third-party systems.

### 3.2 Functional Requirements
This section includes the requirements that specify all the fundamental actions of the software system.
####3.2.1 User Class 1- The Student
#####3.2.1.1 Functional requirement 1.1
TITLE: User registration
DESCRIPTION: Given that a user is a student, he has already been registered in the application by having an email and password given by the university.
RAT: In order for a user to register on the web application.
DEP: none
#####3.2.1.2 Functional requirement 1.2
TITLE: User log-in 
DESCRIPTION: Given that a user is registered, meaning he is a student, he should be able to log in to the web application. The log-in information will be stored on the browser and in the future the user should be logged in automatically.
RAT: In order for a user to log in to the web application.
DEP: none
#####3.2.1.3 Functional requirement 1.3
TITLE: Search for information
DESCRIPTION: Given that a user is log in to the web site, the first page that is shown should be a page for searching information. The student should be able to search for his academical situation, according to the faculty he is taking, in case a student is enrolled to more that one faculty. Also, for each faculty, the student can see the information according to the university year.
In this section he should see all the information available for him to see: fees, academical situation, personal info, courses information.
The documents can be searched: according to the type of file searched, after the date of creation, after the author of the document, after the content of the document.

RAT: In order for a user to search for information in the web application.
DEP: FR1, FR2

#####3.2.1.4 Functional requirement 1.4
TITLE: Selecting the information link
DESCRIPTION: A user should be able to select the information link, which is included on all result items. The link will direct the user to an information page, which includes all the information available according to the link he selected shown as a document or as a table.
RAT: In order to show information.
DEP: FR3


####3.2.2 User Class 2- The Teacher

#####3.2.2.1 Functional requirement 2.1
TITLE: Teacher registration
DESCRIPTION: Given that a user is a teacher, he has already been registered in the application by having an email and password given by the university.
RAT: In order for a user to register on the web application.
DEP: none
#####3.2.2.2 Functional requirement 2.2
TITLE: Teacher log-in 
DESCRIPTION: Given that a user is registered, meaning he is a teacher, he should be able to log in to the web application. The log-in information will be stored on the browser and in the future the user should be logged in automatically.
RAT: In order for a teacher to log in to the web application.
DEP:FR1
#####3.2.2.2 Functional requirement 1.2
TITLE: Writing grades for students
DESCRIPTION: Each teacher is giving grades to the students that are on their classes. The grades can be seen by the secretary and by the students.
RAT: In order to give grades to the students.
DEP: FR1
####3.2.3 User Class 3- The Secretary
#####3.2.3.1 Functional Requirement 3.1
TITLE: Add and Update information about students
DESCRIPTION: A secretary is able to add a student to the data base of the faculty and to update their personal information. Same thing is happening with teachers, which can be added by the secretary.
RAT: In order to add a student or a teacher to the data base.
DEP: none
#####3.2.3.2 Functional Requirement 3.2
TITLE: View information about students and teachers
DESCRIPTION: A secretary is able to view information that exists in the data base about each student and each teacher from the faculty.
RAT: In order to see available information
DEP: FR1
#####3.2.3.3 Functional Requirement 3.3
TITLE: Generate specific reports with information about students
DESCRIPTION: A secretary can generate specific reports with information about each student for each student.
RAT: In order to create necessary reports.
DEP: FR2

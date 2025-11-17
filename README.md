# QTip Coding Challenge

## Submission

### Instructions for running the application

As suggested within the challenge, you can run the solution by running the compose command within the top-level directory which contains the docker-compose.yml
```bash
docker compose up
```
This will build and or pull all required images for the solution to run.

### Architectural decisions and assumptions

Frontend decisions and assumptions
   - Nextjs, this is one of the first times I have used Nextjs and found it quite fun, though I am sure I have accidently used some of it incorrectly e.g. the client vs server side rendering. I wanted to demostrate my ability to pick up new technologies when required. 
   - DaisyUI, this is a component library I use within my general day-to-day and provides well rounded component library based upon tailwindcss.
   - Text input, I decided to build an overlay to the DaisyUI textarea - within this I have used Regex to implement the finding of email pii, for short text this is efficient and simple to implement due to emails structured pattern.
   - Future considerations, I would use a component library with an option to provide custom error handling. Therefore a lot of the processing could be taken care of in the background without the need to maintain complex regex or error handling systems. 
   - Assumptions, due to my knowledge of what Qala use for frontend stack, I tried to use all the technologies they would use.

Backend decisions and assumptions
   - .Net clean architecture, the backend application was built utilising the clean architecture approach for a cleaner more maintainable backend, aditionally various SOLID principles were followed within the build.
   - Postgres, this database was used for ease of use alongside the EF ORM - providing strong typing, change tracking, etc. I chose this over a NoSQL database such as Mongo as it provides more structure, which works nicely for the classification model. 
   - Pii detection, again, like the frontend, Regex was used. Again, like the benefits presented within the frontend, it provided an efficient and simple implementation for finding and replacing key findings within text. 

Additional notes, PGAdmin has also been provided with a pre-configured DB with a username and password. These are purely set up so you can see the data within its raw form within the database.

### Trade-offs or shortcuts taken

Postgres over Mongo. For the submission model, Mongo may have been a more efficient as Postgres could be considered overkill for this small of a solution and for simple token referencing as the solution doesnt take advantage of querying or indexing. 

Clean architecture. For a solution like this, clean may have been overkill for maintainability and being able to easily extend this for the future. 

Regex. If regex input is not controlled approriately, this could lead into a ReDos attack on the solution. 

Classification implementation, the current logic does not reference the submission. If I were to implement this, there is a risk of losing data as its not transactional, wihtout this the submission and classfications could be log. 

Shortcuts, I did not use any scaffolding code to make development faster, though I should have due to time constraints. I used code I have previously built as reference in the instance I got stuck. Additionally, I used regex and flexbox generators both for code and for reference. 

### Optional Extension

Though I did not implement the optional extension due to time contraints, I wanted to provide some thoughts about the implementation I gave and how it could be extended.

If I were to implement the other pii issues, I would continue to utilise Regex. However, I believe a more efficient method should be used within the frontend and backend, to ensure optimal speed - potentially this could have been threaded. 

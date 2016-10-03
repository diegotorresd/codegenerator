*************************************
**                                 **
** A better Mi-Case Code Generator **
**                                 **
*************************************

Contains:
- A CodeGenerator library
- A ConsoleApp client
- A full testsuite to run the tests

Usage:
- compile the solution
- copy the generated exe (and CodeGenerator.dll) to the generator/ folder 
- review the config file to make sure you are using the correct connection string.
- run MiCaseCodeGenerator, passing it the table names and (optionally) the files you want to generate.
e.g.
> MiCaseCodeGenerator --tableNames AZ_DOC_REL_REQUEST DOC_RELIGIOUS_LIMITS --fileTypes DAL Entity DALTests

- run "compile" to check that everything compiles.
- run "test" to compile and run the tests
- "clean_testsuite" resets the testsuite to its initial status
- "clean_results" removes the results folder so you don't have to

ASSUMPTIONS
- There is a package named "PKG_" + the tablename in the database.
- It contains *at least* the following procedures:
	- PR_GET
	- PR_GET_ALL
	- PR_UPDATE
	- PR_INSERT
	- PR_DELETE
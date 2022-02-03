# Algorithm Analytics

## Overview
This is a passion project designed and created by myself(Max1mus7) in order to not only develop my skills as a .NET and C# programmer, but also to one day provide people with a reliable resource for learning about and experimenting with various sorting algorithms in a practical environment. It is currently live and hosted by Microsoft Azure at https://algorithmsapi.azurewebsites.net/ and utilizes a MongoDB database. It also contains an API as referenced below. Feel free to reach out if you have any questions and don't be afraid to improve the project yourself!

## Objectives
1. Provide people with tangible data on how certain sorts work on different sets of data
2. Provide a place for people to sort their own data using different sorts
3. Provide people with a place where they can submit their own sorts and test their efficiencies
4. Provide all of this functionality within a web app and through an outward-facing API

## Implemented Sorts
> At the time of writing this README, each of these sorts can only work with default data.
1. Selection Sort
2. Bubble Sort
3. Insertion Sort
4. Quicksort
5. Merge Sort


## API Functionality
> For a closer look at API documentation, check https://github.com/Max1mus7/Algorithm-Analytics/blob/main/Documentation/AlgoAPI.postman_collection.json.  
> A Swagger version is likely to come in the future. 
### **Sort Types and Names**

Types:
> Replace the \<sort type\> within an API call with one of these unless otherwise specified.
1. number
2. word
3. generic(unimplemented at the time of writing)

Names:
> Replace the \<sort name\> within an API call with one of these unless otherwise specified.
1. Selection Sort - selection
2. Bubble Sort - bubble
3. Insertion Sort - insertion
4. Quicksort - quicksort
5. Merge Sort - merge

### **Analysis Item Structure**
An example of a given analysis item can be described with the following JSON psuedocode:  
`
{"Iterations":<total iterations(int)>,"Attempts":<attempt count(int)>,"SortName":"<sort name(string)>, "AvgIterations":<average iterations per sort(double)>, "JsonList":<JSON list of all data that was sorted(List<List<string>> for you C# developers)}
`

### **Routes**

**The base route for all of these will(at least for the time being) be https://algorithmsapi.azurewebsites.net/api/sorts**  

The base route will be signified in the following routes via the ~ symbol.  

***GET Routes:***  
**Create Data:**  
> ***Create Default sort analysis:***
> - ~/createdefault/\<sort name\>/\<sort type\>
> - For example: ~/createdefault/bubble/number

**Get Data:**  
> ***Get All sort data ever generated*** (warning, this is a LOT of data.)
> - ~/  
> 
> ***Get a specific data piece***  
> - ~/\<id\>  
> 
> *Remember that this application utilizes a MongoDB backend, and therefore utilizes a string of characters as an id, not just a number.*

**Delete Data:**  
> ***Delete an object from the DB given an object's ID***
> - ~/delete/\<id\>
> - This is currently available to anyone, although I plan on implementing authentication in the future to avoid abuse.

***POST Routes:***
> ***Add a custom sort analysis result to the DB***
> - ~/createcustom
> - Ensure that the body is sent in a JSON format and is formatted like the example above, or there will be errors.
> More to be implemented at a later date.

***PUT Routes:***
> To be implemented at a later date.

***DELETE Routes:***
> ***Delete an object from the DB given an object's ID***
> - ~/\<id\>
> - This is currently available to anyone, although I plan on implementing authentication in the future to avoid abuse.

## Installation
To install this project, it should be as simple as downloading the code and opening the solution(AlgorithmSite.sln) within Visual Studio. If not, please contact me at maxdweber7@gmail.com with either a fix or errors. 
\*\*\***Important**\*\*\*
- Each of the folders within the APISorting folder is a project itself and therefore can be run as such. To locally test whether sorts work, please run the SortAnalytics project using the appropriate sort type.
- If you attempt to access the API locally, you WILL timeout. MongoDB will not send/receive information to/from unrecognized IP addresses.

## Contact the Dev
I can be reached at maxdweber7@gmail.com
Please reach out there for comments, concerns, improvement ideas, etc. 
- I will be keeping an eye on this repo as I continue to work on it, and I am certainly open to turning this into a more Open Source project. 
 


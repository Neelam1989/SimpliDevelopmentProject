![sympli logo!](https://www.sympli.com.au/wp-content/uploads/sympli-logo-black.svg)

#### Description about Application
1. Created mock data for showing google Results for e-settlements and www.sympli.com.au.
2. As its mock data did not keep 100 records in Dictionary, just passed top as parameter in method, 
  once we will fetch real google data, we can fetch data based on top parameter as mention in requirment.

## Steps for testing

1. Run the application from Visual studio than enter keyword e-settlements  and Url www.sympli.com.au and click on fetch.
This is then processed to return a string of numbers for where the resulting URL is found in the Google results.
if user enter any other keyword the response will return record not found.

Note : I did no write unit test cases due to less time, if you want me to focus on Unit test cases as well, Please provide me opportunity in second round of interview, i can explain and write.

* Result shows as expected
<img width="1792" alt="Sympali App success result" src="https://user-images.githubusercontent.com/57215858/212584754-b9cc8908-2e9f-47de-8f48-1d50fbbf9a2c.png">

* Negative test, when keyword or Url is something else than it shows records not found(As other records are not available in mock result list)
<img width="1792" alt="Sympali Records Not Fount" src="https://user-images.githubusercontent.com/57215858/212585009-db237627-4f60-459b-8909-470969ecab6b.png">





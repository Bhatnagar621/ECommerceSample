# E-Commerce Inventory system
The project is made in .NET Core Environment.
The assignment was as follows:
+ Create an Inventory database with tables mentioned in Sheet 1 using Entity Framework in the .Net Core 8 class library.
+ Create a Business Logic Layer to create different methods for Crud operations on these tables.
+ Create an API layer to get commands and data from users to interact with inventory db.
+ Place orders by having validations of quantity in inventory for the below cases:
  - return NotFound, if the quantity in order is more than the quantity in inventory.
  - return BadRequest, if quantity is in negatives or zero.
  - return Success, if order is placed by passing these validations."
+ Place 5 orders each belonging to 2 different customers and then create a reporting endpoint, in which you may pass CustomerId
  and it returns all details of orders and products in that order. (Use stored procedure/view to return this data)

  All these steps were implemented and the result for the last point is displayed below in the form of a JSON file:
  ```javascript
      {
        "firstName": "John",
        "lastName": "Doe",
        "email": "johnDoe@abc.com",
        "phoneNumber": "8765943021",
        "orders": [
          {
            "productName": "Phone",
            "productQuantity": 2
          },
          {
            "productName": "Television",
            "productQuantity": 1
          },
          {
            "productName": "Track Suit",
            "productQuantity": 1
          },
          {
            "productName": "Jacket",
            "productQuantity": 1
          },
          {
            "productName": "Tshirt",
            "productQuantity": 2
          },
          {
            "productName": "Hoodie",
            "productQuantity": 1
          }
        ]
      }
  ```
and another customer as 
```javascript
{
  "firstName": "Jane",
  "lastName": "Stark",
  "email": "janestark@avenger.com",
  "phoneNumber": "9876543021",
  "orders": [
    {
      "productName": "Laptop",
      "productQuantity": 1
    },
    {
      "productName": "Phone",
      "productQuantity": 2
    },
    {
      "productName": "Tshirt",
      "productQuantity": 1
    },
    {
      "productName": "Television",
      "productQuantity": 1
    },
    {
      "productName": "Jacket",
      "productQuantity": 2
    }
  ]
}
```

When a product is added to a customer's orders, its quantity gets reduced accordingly in the database.
The tasks that can be performed are:
- Category
  - add category
  - get all categories
  - get category through id
    
- Customer
  - add customer
  - get customer details through id
  - delete customer through id
  - update customer through id
- Order
  - add order 
  - delete order through id

- Product
  - add product
  - get all products
  - get product through id
  - delete product through id
  - update product through id
 
  The error handling was done using Filters as well as Middlewares
  Middleware was used to throw custome httpcontext.Response when an error is caught. 

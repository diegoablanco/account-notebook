## Account notebook challenge

This application consists in an API for managing an account balance, and a simple UI for listing all the account transactions.

## Getting started
The application can be started on Linux by moving to the publish folder
`cd bin/Release/netcoreapp3.1/publish` and executing:
`./account-notebook`

## Using the API
Available enpoints are:
- GET /api
    - retrieves all transactions
- GET /api/{transactionId}
    - retrieves the specific transaction
- POST /api
    - creates a new transaction

Please refer to the challenge documentation for futher details on transaction creation.

## Using the UI
By entering the application URL on a browser default listing page will be show.
Page should be refreshed in order to reflect new transactions.
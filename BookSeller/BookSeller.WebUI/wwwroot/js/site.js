// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//  PRODUCT HTTP GETALL REQUEST

fetch('https://localhost:7086/api/Product/GetAll?pageNumber=1&pageSize=11')
    .then(response => {
        return response.json();
    })
    .then(products => {

        products.data.forEach(function (product) {

            const row = document.getElementById("row");

            let column = document.createElement("div");
            column.className = "col-sm-6";
            column.id = "col-sm-6";
            row.appendChild(column);

            let card = document.createElement("div");
            card.className = "card";
            card.id = "card";
            card.style.marginBottom = "25px";
            column.appendChild(card);

            let cardBody = document.createElement("div");
            cardBody.className = "card-body";
            cardBody.id = "card-body";
            card.appendChild(cardBody);

            let bookName = document.createElement("h5");
            bookName.id = "bookName";
            bookName.className = "card-title";
            bookName.innerHTML = product.bookName;
            cardBody.appendChild(bookName);

            let author = document.createElement("small");
            author.id = "author";
            author.className = "card-title";
            author.textContent = product.author;
            author.style.display = "block";
            cardBody.appendChild(author);


            let publisher = document.createElement("small");
            publisher.id = "publisher";
            publisher.className = "card-title";
            publisher.textContent = product.publisher;
            publisher.style.display = "block";
            cardBody.appendChild(publisher);

            let unitPrice = document.createElement("label");
            unitPrice.id = "unitPrice";
            unitPrice.className = "card-title";
            unitPrice.textContent = product.unitPrice;
            unitPrice.style.display = "block";
            cardBody.appendChild(unitPrice);

        })

    })


// USER HTTP GETALL REQUEST

//fetch('https://localhost:7086/api/User/GetAll?pageNumber=1&pageSize=11')
//    .then(response => {
//        return response.json();
//    })
//    .then(users => {

//        users.data.forEach(function (user) {

//            console.log(user);

//        })

//    })


const token = 'your_token_here'; // Replace 'your_token_here' with the actual token

fetch('https://localhost:7086/api/User/GetAll?pageNumber=1&pageSize=11', {
    headers: new Headers({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json' // You can add other headers if needed
    })
})
    .then(response => {
        return response.json();
    })
    .then(users => {
        users.data.forEach(function (user) {
            console.log(user);
        })
    })
    .catch(error => {
        console.error('Error:', error);
    });




// LOGIN HTTP POST REQUEST

var postData = {
    email: "admin@bookseller.com",
    password: "3R4sl4n_"
}

const login = () => {
    fetch("https://localhost:7086/api/Login/Login", {

        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },

        body: JSON.stringify(postData)
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            console.log('POST işlemi başarıyla tamamlandı:', data);
        })
}
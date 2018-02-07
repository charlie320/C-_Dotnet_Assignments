
// {
//     "DBInfo":
//     {
//         "Name": "PostGresConnect",
//         "ConnectionString": "server=localhost;userId=postgres;password=postgres;port=5432;database=WeddingPlannerDB;"
//     }
// }



    // var theResponse = "";
    // var wedding_address = '@(ViewBag.wedding.WeddingAddress)';
    
    // document.getElementById("demo").innerHTML = wedding_address;


    // function getCoordinates() {
    //     var xhttp = new XMLHttpRequest();
    //     xhttp.onreadystatechange = function() {
    //         if (this.readyState == 4 && this.status == 200) {
    //             document.getElementById("demo").innerHTML = (this.responseText);
    //             theResponse = JSON.parse(this.responseText);
    //             console.log(theResponse.results[0].geometry.location);
    //         }
    //     };
    //     xhttp.open("GET", "https://maps.googleapis.com/maps/api/geocode/json?address=" + wedding_address, true);
    //     xhttp.send();
    // }



    // var theResponse = "";
    // var wedding_address = '@(ViewBag.wedding.WeddingAddress)';
    // var coordinates;
    
    // document.getElementById("demo").innerHTML = wedding_address;

    // function getCoordinates() {
    //     var xhttp = new XMLHttpRequest();
    //     xhttp.onreadystatechange = function() {
    //         if (this.readyState == 4 && this.status == 200) {
    //             document.getElementById("demo").innerHTML = (this.responseText);
    //             theResponse = JSON.parse(this.responseText);
    //             coordinates = theResponse;
    //             console.log(theResponse.results[0].geometry.location);
    //         }
    //     };
    //     xhttp.open("GET", "https://maps.googleapis.com/maps/api/geocode/json?address=" + wedding_address, true);
    //     xhttp.send();
    // }



       
    // var wedding_address = '@ViewBag.wedding.WeddingAddress';
    // var location_info;

    // $.getJSON("https://maps.googleapis.com/maps/api/geocode/json?address=" + wedding_address, function (data, response) {
    //     location_info = JSON.stringify(data);
    //     console.log("Data: " + data);
    //     console.log(location_info);
    // });

    // console.log("Location Info outside: " + location_info);
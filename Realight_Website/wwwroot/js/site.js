firebase.auth().onAuthStateChange(function(user) {
    if (user) {
        //User is signed in
        document.getElementById("user_div").style.display = "block";
        document.getElementById("login_div").style.display = "none";

        var user = firebase.auth().currentUser;

    } else {
        //No user is signed in
        document.getElementById("user_div").style.display = "none";
        document.getElementById("login_div").style.display = "block";
    }
});

function login() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    firebase.auth().signInWithEmailAndPassword(email, password)
        .then((user) => {
            // Signed in 
            document.getElementById("user_div").style.display = "none";
            document.getElementById("login_div").style.display = "block";
        })
        .catch((error) => {
            var errorCode = error.code;
            var errorMessage = error.message;
        });

    window.alert("You are logged in.");
}


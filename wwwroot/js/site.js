// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validateData() {
    let inputText = document.getElementById('inputBox').value;
    if (inputText.slice(0, 1) !== '{' || inputText.slice(-1) !== '}') {
        alert('Data must be entered in JSON object format.');
        return false;
    }
    else {
        return true;
    }
}
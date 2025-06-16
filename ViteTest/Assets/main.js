import './main.css';

window.myApp = window.myApp || {};

function showAlert(message) {
    alert('JS from main: ' + message);
}

window.myApp.showAlert = showAlert;

if (window.location.pathname === '/') {
    import('./index.js').then((module) => {
        window.myApp.indexImage = module.myImage;

        window.dispatchEvent(new Event('myApp:indexReady'));
    });
}
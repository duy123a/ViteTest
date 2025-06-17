import 'bootstrap/dist/css/bootstrap.min.css';
import '../css/main.css';

import $ from 'jquery';
import 'bootstrap';

import './index-page.js';

$(document).ready(function () {
    console.log('jQuery is working with Vite!');
});

//const page = document.body.dataset.page;

//switch (page) {
//    case 'index':
//        import('./index-page.js').then(m => m.default());
//        break;
//}
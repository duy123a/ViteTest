import $ from 'jquery';

const page = document.body.dataset.page;

//export default function () {
//    console.log('test');
//}

$(document).ready(function () {
    if (page == 'index') {
        console.log('Only from index');
    }
});

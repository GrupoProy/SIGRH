//Quill
var toolbarOptions = [
    [{ 'placeholder': ['[GuestName]', '[HotelName]'] }], // my custom dropdown
    ['bold', 'italic', 'underline', 'strike', 'link'],        // toggled buttons
    ['blockquote', 'code-block'],
    ['video', 'formula', 'image'],
    [{ 'header': 1 }, { 'header': 2 }],               // custom button values
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
    [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
    [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
    [{ 'direction': 'rtl' }],                         // text direction

    [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

    [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
    [{ 'font': [] }],
    [{ 'align': [] }],
    //[{ 'myDropdown': ['Option 1', 'Option 2', 'Option 3', 'Option 4', 'Option 5'] }],
    ['clean']                                         // remove formatting button
];

var options = {
    theme: 'snow',
    modules: {
        toolbar: {
            container: toolbarOptions,
            handlers: {
                "placeholder": function (value) {
                    if (value) {
                        const cursorPosition = this.quill.getSelection().index;
                        this.quill.insertText(cursorPosition, value);
                        this.quill.setSelection(cursorPosition + value.length);
                    }
                }
            }
        },
        formula: false          // Include formula module (needs extra css + Katex Script)
    },
    placeholder: 'Halloween is Coming'
}

var container = document.getElementById('customQuill');
var quill = new Quill(container, options);
//Ver opciones agregadas
const placeholderPickerItems = Array.prototype.slice.call(document.querySelectorAll('.ql-placeholder .ql-picker-item'));
placeholderPickerItems.forEach(item => item.textContent = item.dataset.value);
document.querySelector('.ql-placeholder .ql-picker-label').innerHTML = 'Insert placeholder' + document.querySelector('.ql-placeholder .ql-picker-label').innerHTML;


$("#ContentPlaceHolder1_modalGuardarTenor").click(function () {
    var contentQuill = JSON.stringify(quill.getContents());
    console.log('contentQuillContent', quill.getContents());
    console.log('contentQuill', contentQuill);
    $("#hf_containerQuill").val(contentQuill);

});

var quillJS = function () {
    return quill;
}
function obtenerQuill() {
    return quill;
}


var skin = $("body").hasClass("dark") ? "moono-dark" : "moono-lisa";
var editor;

function createPersianEditor(config) {
    CKEDITOR.config.skin = skin;
    editor = CKEDITOR.appendTo('editor', config);
    editor.setData($("#content").val());
}

function createInlineEditor(config) {
    CKEDITOR.config.skin = skin;
    CKEDITOR.disableAutoInline = true;
    CKEDITOR.inline('editor-inline', config);
}

var config = {};

config.language = 'fa';
createEnglishEditor(config);

config.language = 'fa';
config.font_names =
    "Tahoma;" +
    "Nazanin/Nazanin, B Nazanin, BNazanin;" +
    "Yekan/Yekan, BYekan, B Yekan, Web Yekan;" +
    "IranSans/IranSans, IranSansWeb;" +
    "Parastoo/Parastoo;" +
    "Arial/Arial, Helvetica, sans-serif;" +
    "Times New Roman/Times New Roman, Times, serif;";
createPersianEditor(config);

createInlineEditor(config);


function formatangka(objek) {
    a = objek.value; b = a.replace(/[^\d]/g, ""); c = ""; panjang = b.length; j = 0; for (i = panjang; i > 0; i--) { j = j + 1; c = b.substr(i - 1, 1) + c; }
    objek.value = c;
}
function formatangka2(objek) {
    a = objek.value; b = a.replace(/[^0-9.]/, ""); c = ""; panjang = b.length; j = 0; for (i = panjang; i > 0; i--) { j = j + 1; c = b.substr(i - 1, 1) + c; }
    objek.value = c;
}
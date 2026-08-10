// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Mantiene el valor real (no solo su visualización) en mayúsculas.
document.addEventListener("input", (event) => {
    const control = event.target;

    if (control instanceof HTMLInputElement && control.id === "txtRol") {
        const cursorPosition = control.selectionStart;
        control.value = control.value.toUpperCase();

        if (cursorPosition !== null) {
            control.setSelectionRange(cursorPosition, cursorPosition);
        }
    }
});

document.addEventListener("change", (event) => {
    const control = event.target;

    if (control instanceof HTMLInputElement && control.id === "txtRol") {
        control.value = control.value.toUpperCase();
    }
});



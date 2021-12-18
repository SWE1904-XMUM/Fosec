function UpdateCharacterCount(characterCountTextHolder, targetText_length, maxLength) {
    characterCountTextHolder.innerHTML = targetText_length + "/" + maxLength + " characters";
    if (targetText_length > maxLength) {
        characterCountTextHolder.style.color = "#FF0000";
    }
    else {
        characterCountTextHolder.style.color = "#000000";
    }
}

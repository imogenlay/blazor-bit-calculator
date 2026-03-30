window.setCssVariables = (variables) => {
    const root = document.documentElement.style;
    for (const [key, value] of Object.entries(variables)) {
        root.setProperty(key, value);
    }
}
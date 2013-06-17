function storeViewModelFactory(settings) {
    if (settings.tenantId === settings.tenantIdApple) {
        return storeViewModelApple(settings);
    } else {
        return storeViewModelFunc(settings);
    }
}
output "webapp_url" {
  value = azurerm_linux_web_app.contactsapp.default_hostname
}

output "webapp_ips" {
  value = azurerm_linux_web_app.contactsapp.outbound_ip_addresses
}
output "webapp_url" {
  value = azurerm_linux_web_app.tbapp.default_hostname
}

output "webapp_ips" {
  value = azurerm_linux_web_app.tbapp.outbound_ip_addresses
}
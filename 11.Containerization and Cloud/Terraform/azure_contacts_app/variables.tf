variable "resource_group_name" {
  type        = string
  description = "Resource group name in Azure"
}

variable "resource_group_location" {
  type        = string
  description = "Resource group location in Azure"
}

variable "app_service_plan_name" {
  type        = string
  description = "App service plan name in Azure"
}

variable "app_service_name" {
  type        = string
  description = "App service name in Azure"
}

variable "sql_server_name" {
  type        = string
  description = "Sql server name in Azure"
}

variable "sql_database_name" {
  type        = string
  description = "Sql database name in Azure"
}

variable "sql_admin_login" {
  type        = string
  description = "Admin login in Azure"
}

variable "sql_admin_password" {
  type        = string
  description = "Admin password in Azure"
}

variable "firewall_rule_name" {
  type        = string
  description = "Sql firewall rule in Azure"
}

variable "repo_URL" {
  type        = string
  description = "GitHub repo URL"
}
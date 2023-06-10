# Configure the azure provider
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.0.0"
    }
  }
}

provider "azurerm" {
  features {}
}

# Configure resource group
resource "azurerm_resource_group" "bangelov" {
  name     = "bangelov-resources"
  location = "West Europe"
}
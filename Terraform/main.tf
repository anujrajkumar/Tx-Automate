terraform {
  required_version = ">= 0.13" 
  backend "azurerm" {
    resource_group_name  = "__tfstate_RG__"
    storage_account_name = "__tfstate_Storage__"
    container_name       = "__tfstate_Container__"
    key                  = "dotnetdemo.tfstate"
  }
}

provider "azurerm"{
    //version = ""=2.5.0""
    features{}
}

resource "azurerm_resource_group" "rg" {
  name     = var.resource-group-name
  location = var.location
}

resource "azurerm_app_service_plan" "plan" {
  name                = "demo-appserviceplan"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "app-service" {
  name                = var.app-service-name
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.plan.id

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }

  app_settings = {
    "SOME_KEY" = "some-value"
  }

}
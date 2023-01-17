variable "resource-group-name" {
 default = "demo-resource-group1"
  description = "The prefix used for all resources in this example"
}

variable "app-service-name" {
//  default = "demoapp-service"
  description = "The name of the Web App"
}

variable "location" {
  // default = "westus"
  description = "The Azure location where all resources in this example should be created"
}
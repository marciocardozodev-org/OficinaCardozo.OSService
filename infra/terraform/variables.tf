variable "enable_db" { default = true }
variable "app_name" { default = "osservice" }
variable "db_username" { default = "osservice_user" }
variable "db_password" { default = "CHANGEME" }
variable "db_subnet_ids" { type = list(string) }
variable "db_security_group_ids" { type = list(string) }

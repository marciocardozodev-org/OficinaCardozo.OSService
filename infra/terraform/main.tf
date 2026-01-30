# Aurora PostgreSQL para OSService

variable "enable_db" { default = true }
variable "app_name" { default = "osservice" }
variable "db_username" { default = "osservice_user" }
variable "db_password" { default = "CHANGEME" }
variable "db_subnet_ids" { type = list(string) }
variable "db_security_group_ids" { type = list(string) }

resource "aws_db_subnet_group" "main" {
  count      = var.enable_db ? 1 : 0
  name       = "${var.app_name}-db-subnet-group"
  subnet_ids = length(var.db_subnet_ids) > 0 ? var.db_subnet_ids : (try(data.terraform_remote_state.eks.outputs.private_subnet_ids, []))
  tags = {
    Name = "${var.app_name}-db-subnet-group"
  }
}

resource "aws_rds_cluster" "main" {
  count                    = var.enable_db ? 1 : 0
  cluster_identifier       = "${var.app_name}-aurora-cluster"
  engine                   = "aurora-postgresql"
  engine_version           = "15.15"
  master_username          = var.db_username
  master_password          = var.db_password
  database_name            = "osservice"
  vpc_security_group_ids   = length(var.db_security_group_ids) > 0 ? var.db_security_group_ids : (try(data.terraform_remote_state.eks.outputs.eks_security_group_ids, []))
  db_subnet_group_name     = aws_db_subnet_group.main[0].name
  skip_final_snapshot      = true
  backup_retention_period  = 1
  storage_encrypted        = true
  apply_immediately        = true
  tags = {
    Name = "${var.app_name}-aurora-cluster"
  }
}

resource "aws_rds_cluster_instance" "main" {
  count               = var.enable_db ? 1 : 0
  identifier          = "${var.app_name}-aurora-instance-1"
  cluster_identifier  = aws_rds_cluster.main[0].id
  instance_class      = "db.r6g.large"
  engine              = aws_rds_cluster.main[0].engine
  engine_version      = aws_rds_cluster.main[0].engine_version
  publicly_accessible = false
  db_subnet_group_name = aws_db_subnet_group.main[0].name
  tags = {
    Name = "${var.app_name}-aurora-instance-1"
  }
}

output "rds_host" {
  value       = length(aws_rds_cluster.main) > 0 ? aws_rds_cluster.main[0].endpoint : null
  description = "Endpoint do Aurora Cluster"
}

output "rds_reader_host" {
  value       = aws_rds_cluster.main[0].reader_endpoint
  description = "Endpoint de leitura do Aurora Cluster"
}

output "rds_user" {
  value       = var.db_username
  description = "Usuário do Aurora"
}

output "rds_password" {
  value       = var.db_password
  description = "Senha do Aurora"
  sensitive   = true
}

output "rds_db_name" {
  value       = aws_rds_cluster.main[0].database_name
  description = "Nome do banco no Aurora"
}

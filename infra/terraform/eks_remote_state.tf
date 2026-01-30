# Importa outputs do Terraform do EKS para usar subnets e security group da mesma VPC

data "terraform_remote_state" "eks" {
  backend = "s3"
  config = {
    bucket = "oficina-cardozo-terraform-state"
    key    = "eks/prod/terraform.tfstate"
    region = "us-east-1"
  }
}

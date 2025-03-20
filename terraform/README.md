# Infrastructure
The infrastructure is documented and defined in the Terraform files in this folder.
All changes to the infrastructure should be done by updating the tf-files and deploying the change using the pipelines

## Common issues
The repository has 2 pipelines that run in GitHub when you create a Pull Request:
- TF-drift - detects if there are any changes between existing infrastructure and Terraform definition
- TF-plan-apply - creates an execution plan and then applies it (when PR is merged to main branch)

Some of the pipelines will break if the TF-files have some formatting issues.
It is a easy way to solve this issue before pushing the code:
1. Download the terraform.exe file from [HashiCorp](https://developer.hashicorp.com/terraform/install)
	- Then copy it to preffered folder 
	- Add this folder to enviroment variable PATH 
2. Or download [Chocolatey](https://chocolatey.org/install) and run command
	- choco install terraform
3. Run the following command:
	- .\terraform init
	- .\terraform validate
	- .\terraform fmt -recursive
4. If there is an issue in one of the TF-files it will be automatically fixed and list of fixed files will be shown as the output from the command
5. Some IDE extensions (like HashiCorp Terraform for VS Code) will format files on save and provide intellisense 
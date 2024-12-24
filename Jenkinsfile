pipeline {
    agent any

    environment {
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
        PATH = "${DOTNET_ROOT};${env.PATH}"
    }

    stages {
        stage('Restore') {
            steps {
                echo 'Restoring dependencies...'
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo 'Building the project...'
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

        stage('Publish') {
            steps {
                echo 'Publishing the application...'
                bat 'dotnet publish --configuration Release --output publish'
            }
        }

        stage('Docker Build and Push') {
            steps {
                echo 'Building Docker image and pushing to Docker Hub...'
                script {
                    def dockerImage = docker.build("your-dockerhub-username/your-image-name:latest")
                    docker.withRegistry('https://index.docker.io/v1/', 'docker-hub-credentials-id') {
                        dockerImage.push()
                    }
                }
            }
        }
    }

    post {
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed. Check the logs for more details.'
        }
    }
}

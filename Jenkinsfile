pipeline {
    agent any

    environment {
        // Define the .NET installation path
        DOTNET_ROOT = 'C:\\Program Files\\dotnet'
        PATH = "${env.DOTNET_ROOT};${env.PATH}"
    }

    tools {
        // Use .NET as a custom tool if set up in Jenkins
        customTool 'dotnet'
    }

    stages {
        stage('Verify Environment') {
            steps {
                echo 'Verifying .NET installation...'
                script {
                    // Check .NET version to verify setup
                    bat 'dotnet --version'
                }
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo 'Restoring project dependencies...'
                script {
                    // Restore .NET project dependencies
                    bat 'dotnet restore'
                }
            }
        }

        stage('Build Application') {
            steps {
                echo 'Building the project...'
                script {
                    // Build the .NET project
                    bat 'dotnet build --no-restore'
                }
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running tests...'
                script {
                    // Execute unit tests
                    bat 'dotnet test --no-build'
                }
            }
        }

        stage('Publish Application') {
            steps {
                echo 'Publishing the application...'
                script {
                    // Publish the application to the "publish" folder
                    bat 'dotnet publish -c Release -o publish'
                }
            }
        }

        stage('Package with Docker') {
            steps {
                echo 'Building Docker image...'
                script {
                    // Build a Docker image for the application
                    bat 'docker build -t myapp:latest .'
                }
                echo 'Pushing Docker image to Docker Hub...'
                script {
                    // Push the Docker image to Docker Hub
                    withCredentials([string(credentialsId: '0d6bc306-75cb-4a97-b33e-55e074067a31', variable: 'DOCKER_PASSWORD')]) {
                        bat '''
                        echo %DOCKER_PASSWORD% | docker login -u amineurmentor --password-stdin
                        docker push myapp:latest
                        '''
                    }
                }
            }
        }
    }

    post {
        always {
            echo 'Cleaning up workspace...'
            deleteDir()
        }

        success {
            echo 'Pipeline completed successfully!'
        }

        failure {
            echo 'Pipeline failed. Please check the logs for details.'
        }
    }
}

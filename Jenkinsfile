pipeline {
    agent any

    environment {
        // Environment variables (e.g., credentials or API keys)
        DOCKER_IMAGE = 'todolist-app'
        DOCKER_TAG = 'latest'
    }

    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'main', url: 'https://github.com/Amine-UrMenToR/todolist.git'
            }
        }

        stage('Build') {
            steps {
                echo 'Building the project...'
                sh 'dotnet build ToDoListApp.sln'
            }
        }

        stage('Test') {
            steps {
                echo 'Running unit tests...'
                sh 'dotnet test ToDoListApp.sln'
            }
        }

        stage('Package Docker') {
            steps {
                echo 'Building Docker image...'
                script {
                    docker.build("${env.DOCKER_IMAGE}:${env.DOCKER_TAG}")
                }
            }
        }

        stage('Push to Docker Hub') {
            steps {
                echo 'Pushing Docker image to Docker Hub...'
                script {
                    docker.withRegistry('https://index.docker.io/v1/', 'docker-hub-credentials') {
                        docker.image("${env.DOCKER_IMAGE}:${env.DOCKER_TAG}").push()
                    }
                }
            }
        }
    }

    post {
        always {
            echo 'Cleaning up...'
        }
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}

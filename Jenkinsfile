pipeline {
    agent any
    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'main', url: 'https://github.com/Amine-UrMenToR/todolist.git'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build ToDoListApp.sln'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }
        stage('Package Docker') {
            steps {
                sh 'docker build -t todolistapp .'
            }
        }
        stage('Push to Docker Hub') {
            environment {
                DOCKER_USERNAME = 'your-docker-username'
                DOCKER_PASSWORD = 'your-docker-password'
            }
            steps {
                script {
                    docker.withRegistry('', 'dockerhub') {
                        sh 'docker push amineurmentor/todolistapp'
                    }
                }
            }
        }
    }
}

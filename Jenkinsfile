pipeline {
    agent any
    environment {
        DOTNET_HOME = tool name: 'dotnet', type: 'com.cloudbees.jenkins.plugins.customtools.CustomTool'
        PATH = "${env.DOTNET_HOME}:${env.PATH}"
        DOCKER_CREDENTIALS = credentials('0d6bc306-75cb-4a97-b33e-55e074067a31') // Replace with your Docker Hub credentials ID
    }
    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code...'
                checkout scm
            }
        }
        stage('Restore Dependencies') {
            steps {
                echo 'Restoring .NET dependencies...'
                sh 'dotnet restore ToDoListApp.sln'
            }
        }
        stage('Build') {
            steps {
                echo 'Building the project...'
                sh 'dotnet build ToDoListApp.sln --no-restore -c Release'
            }
        }
        stage('Test') {
            steps {
                echo 'Running tests...'
                sh 'dotnet test ToDoListApp.sln --no-build --verbosity normal'
            }
        }
        stage('Publish') {
            steps {
                echo 'Publishing the application...'
                sh 'dotnet publish ToDoListApp.sln -c Release -o ./publish --no-build'
            }
        }
        stage('Package Docker') {
            steps {
                echo 'Building Docker image...'
                sh 'docker build -t my-dockerhub-username/todolistapp:latest ./publish'
            }
        }
        stage('Push to Docker Hub') {
            steps {
                echo 'Pushing Docker image to Docker Hub...'
                sh '''
                echo "$DOCKER_CREDENTIALS_PSW" | docker login -u "$DOCKER_CREDENTIALS_USR" --password-stdin
                docker push my-dockerhub-username/todolistapp:latest
                '''
            }
        }
    }
    post {
        success {
            echo 'Build and deployment succeeded!'
        }
        failure {
            echo 'Build or deployment failed. Check the logs for details.'
        }
    }
}

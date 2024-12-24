pipeline {
    agent any

    environment {
        DOTNET_PATH = '/usr/share/dotnet' // Update this to the path where .NET is installed
        PATH = "${env.DOTNET_PATH}:${env.PATH}"
    }

    stages {
        stage('Clone Repository') {
            steps {
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build Solution') {
            steps {
                sh 'dotnet build --no-restore'
            }
        }

        stage('Run Tests') {
            steps {
                sh 'dotnet test --no-restore --no-build'
            }
        }

        stage('Publish Application') {
            steps {
                sh 'dotnet publish -c Release -o output'
            }
        }

        stage('Dockerize Application') {
            steps {
                script {
                    docker.withRegistry('https://registry.hub.docker.com', 'docker-hub-credentials-id') {
                        sh '''
                        docker build -t your-docker-image-name:latest .
                        docker push your-docker-image-name:latest
                        '''
                    }
                }
            }
        }
    }

    post {
        always {
            echo 'Pipeline execution completed!'
        }
        success {
            echo 'Build and deployment succeeded!'
        }
        failure {
            echo 'Build or deployment failed. Check the logs for details.'
        }
    }
}

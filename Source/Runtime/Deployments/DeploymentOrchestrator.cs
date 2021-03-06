/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Banantre. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Runtime.Services;

namespace Runtime.Deployments
{
    /// <summary>
    /// Represents an implementation of <see cref="IDeploymentOrchestrator"/>
    /// </summary>
    public class DeploymentOrchestrator : IDeploymentOrchestrator
    {
         IDeployers _deployers;
         IDeploymentStepOrchestrator _deploymentStepOrchestrator;

        /// <summary>
        /// Initializes an instance of <see cref="DeploymentOrchestrator"/>
        /// </summary>
        /// <param name="deployers">Deployers to work with</param>
        public DeploymentOrchestrator(IDeployers deployers, IDeploymentStepOrchestrator deploymentStepOrchestrator)
        {
            _deployers = deployers;
            _deploymentStepOrchestrator = deploymentStepOrchestrator;
        }

#pragma warning disable 1591 // Xml Comments
        public void Orchestrate(IServiceManifest serviceManifest)
        {
            var deployer = _deployers.GetByTypeName(serviceManifest.DeployerType);
            ThrowIfDeployerIsNull(serviceManifest.DeployerType, deployer);
            var steps = deployer.GetStepsFor(serviceManifest);
            _deploymentStepOrchestrator.Orchestrate(steps);
        }
#pragma warning restore 1591 // Xml Comments

        void ThrowIfDeployerIsNull(string deployerType, IDeployer deployer)
        {
            if( deployer == null ) throw new DeployerTypeDoesNotExist(deployerType);
        }
        
    }
}
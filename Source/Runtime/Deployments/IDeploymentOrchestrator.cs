/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Banantre. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 using Runtime.Services;
 
namespace Runtime.Deployments
{
    /// <summary>
    /// Defines the engine capable of running <see cref="IDeployment">deployments</see>
    /// </summary>
    public interface IDeploymentOrchestrator
    {
        /// <summary>
        /// Orchestrate all deployments
        /// </summary>
        void Orchestrate(IServiceManifest serviceManifest);
    }
}
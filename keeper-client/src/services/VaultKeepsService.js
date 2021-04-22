import { AppState } from '../AppState'
import { api } from './AxiosService'
import { vaultsService } from './VaultsService'

class VaultKeepsService {
  async createVaultKeep(newVaultKeep) {
    const res = await api.post('api/vaultkeeps', newVaultKeep)
    vaultsService.getKeepsByVaultId(res.data)
  }

  async getKeepsByVaultId(id) {
    try {
      const res = await api.get(`api/vaults/${id}/keeps`)
      AppState.vaultPage = true
      AppState.vaultKeeps = res.data
      return res
    } catch (error) {

    }
  }

  async deleteVaultKeep(id) {
    await api.delete('api/vaultkeeps/' + id)
    AppState.activeVaultKeeps = AppState.activeVaultKeeps.filter(keep => keep.vaultKeepId !== id)
  }
}

export const vaultKeepsService = new VaultKeepsService()

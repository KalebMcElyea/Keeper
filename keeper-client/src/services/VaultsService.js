import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }

  async getVaultsByAccountId() {
    try {
      const res = await api.get('account/vaults')
      AppState.vaults = res.data
    } catch (err) {
      logger.error('Problems in the get vaults by account id', err)
    }
  }

  async createVault(id) {
    await api.post('api/vaults/', id)
    this.getVaultsByAccountId()
  }

  async deleteVault(valId) {
    await api.delete('api/vaults/' + valId)
    const vaultIndex = AppState.vaults.findIndex(v => v.id === valId)
    AppState.vaults.splice(vaultIndex, 1)
  }
}

export const vaultsService = new VaultsService()

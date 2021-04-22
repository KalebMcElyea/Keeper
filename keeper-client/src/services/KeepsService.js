import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      AppState.keeps = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getKeepsByAccountId() {
    try {
      const res = await api.get('/account/keeps')
      AppState.keeps = res.data
    } catch (err) {
      logger.error('Problems in the get keeps by account id', err)
    }
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    const keepIndex = AppState.keeps.findIndex(k => k.id === id)
    AppState.keeps.splice(keepIndex, 1)
  }

  async createKeep(keep) {
    await api.post('api/keeps', keep)
    this.getKeepsByAccountId()
  }

  // Many2Many
  async getKeepsByPublicVault(id) {
    const res = await api.get('api/vaults/' + id + '/keeps')
    logger.log(res)
    AppState.keeps = res.data
  }
}

export const keepsService = new KeepsService()

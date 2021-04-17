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
      const res = await api.get('account/keeps')
      AppState.keeps = res.data
    } catch (err) {
      logger.error('Problems in the get keeps by account id', err)
    }
  }
}
export const keepsService = new KeepsService()

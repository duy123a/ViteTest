import { defineConfig } from 'vite'
import path from 'path'

export default defineConfig({
    appType: 'custom',
    root: path.resolve(__dirname, 'wwwroot'),
    build: {
        manifest: true,
        outDir: path.resolve(__dirname, 'wwwroot/dist'),
        emptyOutDir: true,
        assetsDir: '',
        rollupOptions: {
            input: {
                main: path.resolve(__dirname, 'wwwroot/js/main.js'),
            },
            output: {
                entryFileNames: '[name].js',
                chunkFileNames: '[name].js',
                assetFileNames: '[name].[ext]',
            }
        }
    },
    server: {
        port: 5173,
        strictPort: true,
        hmr: {
            clientPort: 5173
        }
    }
})
